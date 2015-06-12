using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager
{
     /// <summary>
    /// Purpose: Userloyee abstract base class
    /// </summary>
    abstract class User : object
    {
        private static SortedDictionary<string, Media> _Media;
        public const int UserNUMBER = 1000;
        //property
        public uint UserID {get; set;}
        //property
        public UserType UserType { get; set; }        
        //property
        public string UserName{get; set;}
        //protected abstract Etype MediaType();
        /// <summary>
        /// Purpose: Default Constructor
        /// </summary>
        public User() :base()
        {
            UserID= UserNUMBER - 1;
            UserName="";
            Console.WriteLine("Constructor");
        }
        /// <summary>
        /// Purpose: Parameterized Constructor 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="na"></param>
        public User(uint id, string na)
        {
            UserName= na;
            UserID = id;
            UserType = UserType.NONE;
            Console.WriteLine("Paramter constructor");
        }        
        /// <summary>
        ///  /// <summary>
        /// Purpose: Gets the Enumerator values for IEnumerable interface
        /// </summary>
        /// <returns>_education.Values.GetEnumerator()</returns>
        public IEnumerator<Media> GetMediaType()
        {
            return _Media.Values.GetEnumerator();
        }       
        /// <summary>
        /// purpose: ToString printout
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("UserID: {0}\r\n UserName: {1} ", UserID, UserName);

        }
    }
}
