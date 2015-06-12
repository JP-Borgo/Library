using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Library_Manager
{
    class DVD:Media,ISerializable
    {
        //property
        public UserType UserType { get; set; }
        public MediaType MediaType { get; set; }
        public const int MediaNUMBER = 1000;
        //property
        public DateTime CheckOutDate { get; set; }
        //property
        public uint MediaID {get; set;}
        //property
        public string MediaID1 { get; set; }  
        //property
        public string MediaName{get; set;}
        //property
        public int Status{get; set;}
        //protected abstract Etype MediaType();
        /// <summary>
        /// Purpose: Default Constructor
        /// </summary>
        public DVD() :base()
        {
            MediaID= MediaNUMBER - 1;
            MediaName="";
            CheckOutDate = DateTime.Now.AddDays(-1);
            Console.WriteLine("Constructor");
        }
        /// <summary>
        /// //Purpose: Parameterized Constructor 
        /// Parameters (int id, string firstName, string lastName) 
        /// constrain’s and any returned values
        /// </summary>
        /// <param name="id"> MediaID</param>
        /// <param name="Fna"> MediaFirstName</param>
        /// <param name="Lna">MediaLastName</param>
        public DVD(uint id, string na, DateTime date)
        {
            MediaName= na;
            MediaID = id;
            CheckOutDate = date;
            Console.WriteLine("Paramter constructor");
        }
        public DVD(uint id, string na, DateTime date, MediaType media)
        {
            MediaName = na;
            MediaID = id;
            CheckOutDate = date;
            MediaType = media;
            Console.WriteLine("Paramter constructor");
        }
        public DVD(string id, string na, int st)
        {
            MediaName = na;
            MediaID1 = id;
            Status = st;
            Console.WriteLine("Paramter constructor");
        } 
        /// <summary>
        /// purpose:constructor for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public DVD(SerializationInfo info, StreamingContext ctxt)
        {
            this.MediaID1 = (string)info.GetValue("ID", typeof(string));
            this.MediaID = uint.Parse((string)info.GetValue("ID", typeof(string)));
            this.MediaName = (string)info.GetValue("MediaName", typeof(string));
            this.CheckOutDate = DateTime.Parse((string)info.GetValue("Date", typeof(string)));
            this.Status = int.Parse((string)info.GetValue("Status", typeof(string)));
        }
        /// <summary>
        /// purpose: get course object
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("ID", this.MediaID);
            info.AddValue("ID", this.MediaID1);
            info.AddValue("MediaName", this.MediaName);
            info.AddValue("CheckOutDate", this.CheckOutDate);
            info.AddValue("Status", this.Status);
        }
        protected MediaType GetMediaType()
        {
            return MediaType.DVD;
        }
    }
}
