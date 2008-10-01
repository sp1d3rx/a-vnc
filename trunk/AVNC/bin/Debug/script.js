var rrate = $RRATE;
var mouseX = 0, mouseY = 0, mouseB = 0;
var dragStartX = 0, dragStartY = 0, dragStartB = 0;
var dragEndX = 0, dragEndY = 0, dragEndB = 0;
var freshener = 0;
var keybuff = "";


// This handles the WhatsNew / Refresh Rate for us... setInterval will keep calling the function at the interval. In this case, its "whatsNew"...
if (rrate>0) setInterval("whatsNew();", rrate*1000);

if (document.all) // for IE
{
	document.onmousedown = mouseDown;
	document.onmouseup = mouseUp;
}
else // for FF
{
	document.onmousedown = mouseDown;
	document.onmouseup = mouseUp;
	document.onclick = FFClick;
}

document.onkeypress = keyboardHandler;

whatsNew();

function FFClick(e)
{
	e.preventDefault();
	e.stopPropagation();
	
	return false;
}

function mouseDown(e)
{
	if (!e)
		e = window.event; // compatibility fix for IE
		
	if(e.pageX){ // not IE (Firefox / Opera / Etc)
		mouseX = e.pageX;
		mouseY = e.pageY;
		mouseB = e.which;
	
		if(mouseB == 3)
			mouseB = 2;
	}

	else{ // IE
		mouseX = e.clientX + document.body.scrollLeft + document.documentElement.scrollLeft -2; // IE still offsets by 2 even though the CSS is pixel specific.
		mouseY = e.clientY + document.body.scrollTop + document.documentElement.scrollTop -2;
		mouseB = e.button;
	}

	dragStartX = mouseX;
	dragStartY = mouseY;
	dragStartB = mouseB;

	return false;
}

function mouseUp(e)
{
	if (!e) e = window.event; // compatibility fix for IE
	
	if(e.pageX) { // not IE (Firefox / Opera / Etc)
		mouseX = e.pageX;
		mouseY = e.pageY;
		mouseB = e.which;
	
		if(mouseB == 3) 
			mouseB = 2; // compatibility fix for FireFox
			
	} else { // IE
		mouseX = e.clientX + document.body.scrollLeft + document.documentElement.scrollLeft -2; // IE still offsets by 2 even though the CSS is pixel specific.
		mouseY = e.clientY + document.body.scrollTop + document.documentElement.scrollTop -2;
	
		mouseB = e.button;
	}

	dragEndX = mouseX;
	dragEndY = mouseY;
	dragEndB = mouseB;
	
	if(dragEndX == dragStartX && dragEndY == dragStartY) // no movement - its a single click, not a drag.
	{
		send("sendClick "+mouseX+" "+mouseY+" "+mouseB);
	}
	else
	{
		send("sendDrag "+dragStartX+" "+dragEndX+" "+dragStartY+" "+dragEndY+" "+mouseB);
	}
	
	return false;
}


//function keyboardHandler(e)
//{
//	send("sendStroke "+e.which);
//	
//	return false;
//}

function keyboardHandler(e) // Inspired by Nagle's algorithm... http://en.wikipedia.org/wiki/Nagle's_algorithm
{
	if (keybuff == "")keybuff = e.which; // no keys buffered, then don't add comma
	else{keybuff = keybuff + "," + e.which;} // otherwise, add a comma before adding your key to the buffer
	if(!(typeof nagle == "undefined")){clearTimeout(nagle);} // if there's a timeout set on SendKeys, clear it...
	nagle = setTimeout("SendKeys()",250) // set new timeout to 250ms....
	return false;
}

function SendKeys() 
{

//	document.getElementById("painting").innerHTML=keybuff; // debug only
	send("sendStroke " + keybuff)
	keybuff = "";
}



function send(req)
{
	var xhr = window.XMLHttpRequest ? new XMLHttpRequest() : new ActiveXObject("MSXML2.XMLHTTP.3.0");
	
	xhr.onreadystatechange = function () 
		{
			if((xhr.readyState==4) && (xhr.responseText.indexOf("IMGS")>=0))
				newImages(xhr.responseText);
		}
	
	xhr.open("GET", req, true);
	xhr.send(null);
}

/*
	This function updates new images.
	I use the dummy variable 'd' in the source of the image to 
	prevent browsers from loading from the cache.
*/
function newImages(str)
{
	var newStr = str.split('\n');
	freshener = freshener + 1; //ooh right.. this is a much better solution.. sorry :P
	
	for(var i=1; i<newStr.length; i++)
		document.getElementById(newStr[i]).src = newStr[i]+"?d="+ (++freshener);
}

function whatsNew()
{
	send("whatsNew");

}