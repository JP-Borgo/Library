using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Library_Manager
{
    class Data
    {   
        public List<Media> MediaData;
        public List<Media> GetEmpData { get { return MediaData; } }
        Dictionary<int, Media> test = new Dictionary<int, Media>();
        public Data()
        {
            MediaData = new List<Media>();
            MediaData.Add(new DVD("10001", "PETER", 1));
            MediaData.Add(new DVD("10002", "PETER", 1));
            MediaData.Add(new DVD("10003", "PETER", 1));
            MediaData.Add(new DVD("10004", "PETER", 1));
            MediaData.Add(new DVD("10005", "PETER", 1));
            MediaData.Add(new DVD("10006", "PETER", 1));
            MediaData.Add(new VIDEOTAPE("10101", "PETER", 1));
            MediaData.Add(new VIDEOTAPE("10101", "PETER", 1));
            MediaData.Add(new VIDEOTAPE("10102", "PETER", 1));
            MediaData.Add(new VIDEOTAPE("10103", "PETER", 1));
            MediaData.Add(new VIDEOTAPE("10104", "PETER", 1));
            MediaData.Add(new VIDEOTAPE("10105", "PETER", 1));
            MediaData.Add(new VIDEOTAPE("10106", "PETER", 1));
            MediaData.Add(new ADULT_BOOKS("10201", "PETER", 14));
            MediaData.Add(new ADULT_BOOKS("10202", "PETER", 14));
            MediaData.Add(new ADULT_BOOKS("10203", "PETER", 14));
            MediaData.Add(new ADULT_BOOKS("10204", "PETER", 14));
            MediaData.Add(new ADULT_BOOKS("10205", "PETER", 14));
            MediaData.Add(new ADULT_BOOKS("10206", "PETER", 14));
            MediaData.Add(new CHILDREN_BOOK1("10301", "PETER", 7));
            MediaData.Add(new CHILDREN_BOOK1("10302", "PETER", 7));
            MediaData.Add(new CHILDREN_BOOK1("10303", "PETER", 7));
            MediaData.Add(new CHILDREN_BOOK1("10304", "PETER", 7));
            MediaData.Add(new CHILDREN_BOOK1("10305", "PETER", 7));
            MediaData.Add(new CHILDREN_BOOK1("10306", "PETER", 7));
            
        }
    }
}
