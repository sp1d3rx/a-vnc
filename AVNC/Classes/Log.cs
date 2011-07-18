namespace AVNC.Classes
{
    internal class Log
    {
        private string title;
        private string value;
        private string ip;
        private string time;

        public Log(string title, string value, string time, string ip)
        {
            this.title = title;
            this.value = value;
            this.time = time;
            this.ip = ip;
        }

        public string getTitle()
        {
            return title;
        }

        public string getValue()
        {
            return value;
        }

        public string getTime()
        {
            return time;
        }

        public string getIp()
        {
            return ip;
        }
    }
}