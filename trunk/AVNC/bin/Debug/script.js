var rrate = $RRATE;
var keyrate = 250;
var mouseX = 0, mouseY = 0, mouseB = 0;
var dragStartX = 0, dragStartY = 0, dragStartB = 0;
var dragEndX = 0, dragEndY = 0, dragEndB = 0;
var freshener = 0;
var keybuff = "";
var keyb = setInterval("SendKeys();",keyrate);


// This handles the WhatsNew / Refresh Rate for us... setInterval will keep calling the function at the interval. In this case, its "whatsNew"...
if (rrate>0) setInterval("whatsNew();", rrate*200);

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

if(window.addEventListener)
{
	window.addEventListener("keypress", keyPressHandler, true);
	window.addEventListener("keyup", keyUpHandler, true);
	window.addEventListener("keydown", keyDownHandler, true);
}
else 
if (document.addEventListener)
{
	document.addEventListener("keypress", keyPressHandler, true);
	document.addEventListener("keyup", keyUpHandler, true);
	document.addEventListener("keydown", keyDownHandler, true);
}
else
{
	document.onkeypress = keyPressHandler;
	document.onkeyup = keyUpHandler;
	document.onkeydown = keyDownHandler;
}


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
	
}


//function keyboardHandler(e)
//{
//	send("sendStroke "+e.which);
//	
//	return false;
//}
function keyUpHandler(e)
{
	if (!e)
		e = window.event; // compatibility fix for IE
	if (e.stopPropagation) 
	{
		e.stopPropagation();
	} 
	else 
	{
		e.cancelBubble = true;
	}
	if (e.preventDefault) 
	{
		e.preventDefault();
	}
	else
	{
		e.returnValue = false;
	}
	return false;
}
function keyPressHandler(e) 
{
	if (!e)
		e = window.event; // compatibility fix for IE
	if (e.stopPropagation) 
	{
		e.stopPropagation();
	} 
	else 
	{
		e.cancelBubble = true;
	}
	if (e.preventDefault) 
	{
		e.preventDefault();
	}
	else
	{
		e.returnValue = false;
	}
	return false;
}

function keyDownHandler(e) 
{
	if (!e)
		e = window.event; // compatibility fix for IE
	var kc = "";
	if (e.shiftKey) kc=kc+"%2B"; //URLencoded
	if (e.ctrlKey) kc=kc+"%5E";
	if (e.altKey) kc=kc+"%25";
	var keyCode = e.charCode? e.charCode : e.keyCode // ie or fx or anything else...
	if (keyCode) 
	{
		switch (keyCode) //keycode converter http://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.aspx
		{
			case 16: 
			case 17:
			case 18:
				kc="";
				break; //ignore ctrl, shift and alt
			case 8:
				kc=kc+"{BACKSPACE}";
				break;
			case 9:
				kc=kc+"{TAB}";
				break;	
			case 13:
				kc=kc+"{ENTER}";
				break;
			case 19:
				kc=kc+"{BREAK}";
				break;	
			case 20:
				kc=kc+"{CAPSLOCK}";
				break;	
			case 27:
				kc=kc+"{ESC}";
				break;				
			case 33:
				kc=kc+"{PGUP}";
				break;			
			case 34:
				kc=kc+"{PGDN}";
				break;	
			case 35:
				kc=kc+"{END}";
				break;	
			case 36:
				kc=kc+"{HOME}";
				break;
			case 37:
				kc=kc+"{LEFT}";
				break;
			case 38:
				kc=kc+"{UP}";
				break;
			case 39:
				kc=kc+"{RIGHT}";
				break;		
			case 40:
				kc=kc+"{DOWN}";
				break;
			case 45:
				kc=kc+"{INSERT}";
				break;				
			case 46:
				kc=kc+"{DELETE}";
				break;			
			case 106:
				kc=kc+"{MULTIPLY}";
				break;	
			case 107:
				kc=kc+"{ADD}";
				break;	
			case 109:
				kc=kc+"{SUBTRACT}";
				break;	
			case 111:
				kc=kc+"{DIVIDE}";
				break;		
			case 112:
				kc=kc+"{F1}";
				break;	
			case 113:
				kc=kc+"{F2}";
				break;	
			case 114:
				kc=kc+"{F3}";
				break;
			case 115:
				kc=kc+"{F4}";
				break;	
			case 116:
				kc=kc+"{F5}";
				break;	
			case 117:
				kc=kc+"{F6}";
				break;	
			case 118:
				kc=kc+"{F7}";
				break;	
			case 119:
				kc=kc+"{F8}";
				break;
			case 120:
				kc=kc+"{F9}";
				break;	
			case 121:
				kc=kc+"{F10}";
				break;	
			case 122:
				kc=kc+"{F11}";
				break;	
			case 123:
				kc=kc+"{F12}";
				break;	
			case 144:
				kc=kc+"{NUMLOCK}";
				break;
			case 145:
				kc=kc+"{SCROLLLOCK}";
				break;
			case 32:
			    kc=kc+"%20";
				break;
			case 186:
				kc=kc+"{;}"
				break;
			case 187:
				kc=kc+"{=}"
				break;
			case 188:
				kc=kc+"{,}"
				break;
			case 189:
				kc=kc+"{-}"
				break;
			case 190:
				kc=kc+"{.}"
				break;
			case 191:
				kc=kc+"{/}"
				break;
			case 219:
				kc=kc+"{[}"
				break;
//			case 220:

			case 221:
				kc=kc+"{]}"
				break;
			case 222:
				kc=kc+"{'}"
				break;
			default:
				kc=kc+"{"+String.fromCharCode(keyCode).toLowerCase()+"}";
				break;
		}
		if (kc && kc != "") keybuff = keybuff + kc; // otherwise, add a comma before adding your key to the buffer
		//else keybuff = keybuff + "," + kc;
		
		//if (kc) send("sendStroke " + kc);
	}
	if (e.stopPropagation) 
	{
		e.stopPropagation();
	} 
	else 
	{
		e.cancelBubble = true;
	}
	if (e.preventDefault) 
	{
		e.preventDefault();
	}
	else
	{
		e.returnValue = false;
	}
	if(!(typeof keyb == "undefined")){clearTimeout(keyb);} // if there's a timeout set on SendKeys, clear it...
	keyb = setTimeout("SendKeys()",keyrate) // set new timeout to 250ms
	return false;
}

function SendKeys() 
{
    if (keybuff)
	{
	//	document.getElementById("painting").innerHTML=keybuff; // debug only
		send("sendStroke " + keybuff);
		keybuff = "";
	}
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
	//alert(len(str));
	var newStr = str.split('\n');
	// new functionality - use client-side caching for speedup. imagenum is folder, imagechk is filename
	// actually imagenum is tied to location, imagechk is tied to the checksum.
	if(newStr.length != 1)
	{
	for(var i=1; i<newStr.length; i++)
	{
		stri = newStr[i];
		slashchar = stri.indexOf('/');
		imagenum = stri.substr(0,slashchar);
		imagechk = stri.substr(slashchar+1, stri.length);
		document.getElementById(imagenum).src = imagenum + '/' + imagechk;
	}
	}
}

function whatsNew()
{
	send("whatsNew");

}