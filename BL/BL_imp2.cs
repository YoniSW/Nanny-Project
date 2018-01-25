using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;

namespace BL
{

    partial class Bl_imp : IBL
    {
        static long[] idMotherArray = new long[21];
        static long[] idNannyArray = new long[20];
        static long[] _childIDArray = new long[30];
        string[] recomandactions = new string[]
        {
            "מטפלת מעולה",
            "אחת בדורה",
            "מאוד מרוצה ממנה",
            "עושה מעל ומעבר",

        };

        void initilizeArray()
        {

            for (int i = 0; i < 30; i++)
                _childIDArray[i] = IDCreator("child");
            for (int i = 0; i < 20; i++)
                idNannyArray[i] = IDCreator("nanny");
            for (int i = 0; i < 21; i++)
                idMotherArray[i] = IDCreator("mother");
        }
        /// <summary>
        /// create id for objects ranomaly, 
        /// TypeObject options: nanny,mother,child
        /// </summary>
        long IDCreator(string type)
        {
            long id = 0;
            switch (type)
            {
                case "nanny":
                    do
                    {
                        id = r.Next(100000000, 299999999);
                    } while (idNannyArray.Any(x => x == id));
                    break;
                case "mother":
                    do
                    {
                        id = r.Next(300000000, 599999999);
                    } while (idMotherArray.Any(x => x == id));
                    break;
                case "child":
                    do
                    {
                        id = r.Next(600000000, 999999999);
                    } while (_childIDArray.Any(x => x == id));
                    break;
            }
            return id;
        }

        /// <summary>
        /// Initilize & addtion to list 20 nannies
        /// </summary>
        void NannyInitilize()
        {
            Nanny Ayala_Zehavi = new Nanny
            {

                _nannyID = idNannyArray[0],
                _nannyFname = "אילה",
                _nannyLname = "זהבי",
                _nannyBirth = new DateTime(1980, 5, 19),
                _nannyAdress = "רחוב בית הדפוס 21, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 3,
                _nannyPhone = 0523433333,
                _maxMonthAge = 14,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _recommendation = recomandactions[0],
                _isTamatNanny = false,
                _acceptByHour = true,
                _rateByHour = 10,
                _rateByMonth = 800,
                _workDays = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 15, 0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,8,30,0),
                    new DateTime(01,01,1,8,30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,20,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,15,10,0),
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,0,0,0),
                },

            };
            Nanny Moria_schneider = new Nanny
            {
                _recommendation = "Very good",
                _nannyID = idNannyArray[1],
                _nannyFname = "שניידר",
                _nannyLname = "מוריה",
                _nannyBirth = new DateTime(1980, 5, 19),
                _nannyAdress = "רחוב שחל 15, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 3,
                _nannyPhone = 0523433333,
                _maxMonthAge = 14,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = true,
                _rateByHour = 10,
                _rateByMonth = 800,
                _isTamatNanny = false,
                _workDays = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 0, 0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,17,45,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                //_recommendation = "",
            };
            Nanny malki_fishman = new Nanny
            {

                _recommendation = "Very bad",
                _nannyID = idNannyArray[2],
                _nannyFname = "מלכי",
                _nannyLname = "פישמן",
                _nannyBirth = new DateTime(1992, 4, 9),
                _nannyAdress = "רחוב בר אילן 15, ירושלים",
                _isElevator = false,
                _floor = 1,
                _yearsOfExp = 5,
                _nannyPhone = 0525633333,
                _maxMonthAge = 17,
                _minMonthAge = 1,
                _maxamountChildren = 7,
                _acceptByHour = false,
                _isTamatNanny = true,
                _rateByMonth = 1200,
                _workDays = new bool[6] { true, true, true, true, true, true },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 8, 0, 0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,8,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,45,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,16,15,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,12,0,0),
                },
                //_recommendation = recomandactions[1],
            };
            Nanny Elisheva_Shaked = new Nanny
            {
                _recommendation = "loves kids!",
                _nannyID = idNannyArray[3],
                _nannyFname = "אלישבע",
                _nannyLname = "שקד",
                _nannyBirth = new DateTime(1990, 5, 29),
                _nannyAdress = "עמרם גאון 15, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 3,
                _nannyPhone = 0523433333,
                _maxMonthAge = 14,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = true,
                _rateByHour = 10,
                _isTamatNanny = false,
                _rateByMonth = 800,
                _workDays = new bool[] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,20,0),
                    new DateTime(01,01,1,7,50,0),
                    new DateTime(01,01,1,7,40,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,15,40,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,15,10,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,15,35,0),
                    new DateTime(),
                },
                //_recommendation = recomandactions[0],
            };
            Nanny Yafi_Shtain = new Nanny
            {
                _recommendation = "Very expensive",
                _nannyID = idNannyArray[4],
                _nannyFname = "יפי",
                _nannyLname = "שטיין",
                _nannyBirth = new DateTime(1995, 1, 8),
                _nannyAdress = "הרב פנחס קהתי 5, ירושלים",
                _isElevator = true,
                _floor = 4,
                _yearsOfExp = 1,
                _nannyPhone = 0526754123,
                _maxMonthAge = 18,
                _minMonthAge = 2,
                _maxamountChildren = 6,
                _acceptByHour = true,
                _rateByHour = 12,
                _rateByMonth = 800,
                _isTamatNanny = true,
                _workDays = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 15, 0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,15,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(),
                },
                //_recommendation = recomandactions[3],
            };
            Nanny Hila_Sharabi = new Nanny
            {
                _recommendation = "Very cheap",
                _nannyID = idNannyArray[5],
                _nannyFname = "הילה",
                _nannyLname = "שרעבי",
                _nannyBirth = new DateTime(1990, 5, 19),
                _nannyAdress = "אליעזרוב 15, ירושלים",
                _isElevator = false,
                _floor = 0,
                _yearsOfExp = 6,
                _nannyPhone = 0509856634,
                _maxMonthAge = 18,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = false,
                _rateByMonth = 950,
                _isTamatNanny = true,
                _workDays = new bool[6] { true, true, true, false, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(1,1,1,16,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(),
                },
                //_recommendation = recomandactions[2],
            };
            Nanny Adi_Shushan = new Nanny
            {
                _recommendation = "kids like her",
                _nannyID = idNannyArray[6],
                _nannyFname = "עדי",
                _nannyLname = "שושן",
                _nannyBirth = new DateTime(1970, 5, 14),
                _nannyAdress = "רחוב היהודים 4, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 30,
                _nannyPhone = 0548435465,
                _maxMonthAge = 24,
                _minMonthAge = 1,
                _maxamountChildren = 8,
                _acceptByHour = true,
                _rateByHour = 10,
                _isTamatNanny = true,
                _rateByMonth = 800,
                _workDays = new bool[6] { true, true, true, true, false, true },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 0, 0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(),
                    new DateTime(01,01,1,7,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,13,30,0),
                },
                //_recommendation = recomandactions[1],
            };
            Nanny Chavi_Horen = new Nanny
            {
                _recommendation = "stay away",
                _nannyID = idNannyArray[7],
                _nannyFname = "חווי",
                _nannyLname = "הורן",
                _nannyBirth = new DateTime(1994, 5, 9),
                _nannyAdress = "rusalemמאה שערים 8 ירושלים",
                _isElevator = false,
                _floor = 2,
                _yearsOfExp = 3,
                _nannyPhone = 0573124354,
                _maxMonthAge = 12,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = true,
                _rateByHour = 11,
                _rateByMonth = 1100,
                _isTamatNanny = false,
                _workDays = new bool[6] { false, true, true, true, true, true },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 0, 0, 0),
                    new DateTime(01,01,1,8,15,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,11,30,0),
                },
                //_recommendation = recomandactions[3],
            };
            Nanny Diti_Farkash = new Nanny
            {
                _recommendation = "Diti we love you!",
                _nannyID = idNannyArray[8],
                _nannyFname = "דיטי",
                _nannyLname = "פרקש",
                _nannyBirth = new DateTime(1987, 3, 19),
                _nannyAdress = "רחוב המחנכת 8, ירושלים",
                _isElevator = false,
                _floor = 2,
                _yearsOfExp = 8,
                _nannyPhone = 0526785431,
                _maxMonthAge = 18,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = true,
                _rateByHour = 8,
                _rateByMonth = 800,
                _isTamatNanny = true,
                _workDays = new bool[6] { true, true, true, true, true, true },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,8,30,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,7,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,15,0,0),
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,12,30,0),
                },
                //_recommendation = recomandactions[1],
            };
            Nanny noa_Karlibach = new Nanny
            {
                _recommendation = "Noa my kids miss you",
                _nannyID = idNannyArray[9],
                _nannyFname = "נעה",
                _nannyLname = "קרליבך",
                _nannyBirth = new DateTime(1984, 8, 19),
                _nannyAdress = "רחוב סולם יעקב 18, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 10,
                _nannyPhone = 0527612345,
                _maxMonthAge = 15,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = false,
                _rateByMonth = 1000,
                _isTamatNanny = true,
                _workDays = new bool[6] { false, true, false, true, true, true },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 0, 0, 0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,12,30,0),
                },
                //_recommendation = recomandactions[1],

            };
            Nanny batSheva_Choen = new Nanny
            {
                //v
                _nannyID = idNannyArray[10],
                _nannyFname = "בתשבע",
                _nannyLname = "כהן",
                _nannyBirth = new DateTime(1996, 5, 19),
                _nannyAdress = "רחוב יצחק מרסקי 8, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 0,
                _nannyPhone = 0526872034,
                _maxMonthAge = 18,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = true,
                _rateByHour = 9,
                _rateByMonth = 800,
                _isTamatNanny = false,
                _workDays = new bool[6] { true, true, true, false, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,17,15,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                //_recommendation = "",
            };
            Nanny Mehira_Shulman = new Nanny
            {
                _nannyID = idNannyArray[11],
                _nannyFname = "מאירה",
                _nannyLname = "שולמן",
                _nannyBirth = new DateTime(1990, 1, 1),
                _nannyAdress = "רחוב בר אילן 32, ירושלים",
                _isElevator = true,
                _floor = 1,
                _yearsOfExp = 3,
                _nannyPhone = 0523421347,
                _maxMonthAge = 15,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = false,
                _rateByMonth = 900,
                _isTamatNanny = false,
                _workDays = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                //_recommendation = recomandactions[1],
            };
            Nanny Avigail_Kuk = new Nanny
            {
                //v
                _nannyID = idNannyArray[12],
                _nannyFname = "אביגיל",
                _nannyLname = "קוק",
                _nannyBirth = new DateTime(1990, 5, 12),
                _nannyAdress = "רחוב רבינו גרשום 32, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 3,
                _nannyPhone = 0523908761,
                _maxMonthAge = 18,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = true,
                _rateByHour = 10,
                _rateByMonth = 950,
                _isTamatNanny = false,
                _workDays = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,45,0),
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                //_recommendation = recomandactions[0],
            };
            Nanny Chani_Yosef = new Nanny
            {
                //v
                _nannyID = idNannyArray[13],
                _nannyFname = "חני",
                _nannyLname = "יוסף",
                _nannyBirth = new DateTime(1994, 2, 19),
                _nannyAdress = "רחוב סולם יעקב 12, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 3,
                _nannyPhone = 0526545524,
                _maxMonthAge = 14,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = true,
                _rateByHour = 10,
                _rateByMonth = 800,
                _isTamatNanny = true,
                _workDays = new bool[6] { true, true, true, true, true, true },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 8, 0, 0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12,30,0),
                },
                //_recommendation = recomandactions[3],
            };
            Nanny Batya_Adler = new Nanny
            {
                //v
                _nannyID = idNannyArray[14],
                _nannyFname = "בתיה",
                _nannyLname = "אדלר",
                _nannyBirth = new DateTime(1990, 7, 13),
                _nannyAdress = "רחוב שחל 17, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 3,
                _nannyPhone = 0525476532,
                _maxMonthAge = 18,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = false,
                _rateByMonth = 650,
                _isTamatNanny = false,
                _workDays = new bool[6] { true, true, false, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,0,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,16,15,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,0,0,0),
                },

                //_recommendation = recomandactions[1],
            };
            Nanny lea_Gans = new Nanny
            {
                _nannyID = idNannyArray[15],
                _nannyFname = "לאה",
                _nannyLname = "גנץ",
                _nannyBirth = new DateTime(1990, 9, 30),
                _nannyAdress = "רחוב רבינו גרשום 4, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 3,
                _nannyPhone = 0527832415,
                _maxMonthAge = 14,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = true,
                _rateByHour = 10,
                _rateByMonth = 1000,
                _isTamatNanny = true,
                _workDays = new bool[6] { false, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 0, 0, 0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,0,0,0),
                },

                //_recommendation = recomandactions[2],
            };
            Nanny Miryam_BenHamu = new Nanny
            {
                //v
                _nannyID = idNannyArray[16],
                _nannyFname = "מרים",
                _nannyLname = "בן-חמו",
                _nannyBirth = new DateTime(1985, 5, 19),
                _nannyAdress = "רחוב שמואל הנביא 17, ירושלים  ",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 8,
                _nannyPhone = 0521234983,
                _maxMonthAge = 15,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = true,
                _rateByHour = 12,
                _rateByMonth = 900,
                _isTamatNanny = false,
                _workDays = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,0,0,0),
                },

                //_recommendation = recomandactions[0],
            };
            Nanny Gila_Elmagor = new Nanny
            {
                _nannyID = idNannyArray[17],
                _nannyFname = "גילה",
                _nannyLname = "אלמגור",
                _nannyBirth = new DateTime(1977, 10, 16),
                _nannyAdress = "רחוב שמואל הנביא 5, ירושלים",
                _isElevator = true,
                _floor = 6,
                _yearsOfExp = 3,
                _nannyPhone = 0529876543,
                _maxMonthAge = 12,
                _minMonthAge = 2,
                _maxamountChildren = 8,
                _acceptByHour = false,
                _rateByHour = 10,
                _rateByMonth = 800,
                _isTamatNanny = true,
                _workDays = new bool[6] { true, true, true, true, false, true },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 30, 0),
                    new DateTime(01,01,1,7,30,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,7,0,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,8,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,17,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,0,0,0),
                    new DateTime(01,01,1,13,0,0),
                },

                ////_recommendation = recomandactions[1],
            };
            Nanny Tsipi_Hotoveli = new Nanny
            {
                //v
                _nannyID = idNannyArray[18],
                _nannyFname = "ציפי",
                _nannyLname = "חוטובלי",
                _nannyBirth = new DateTime(1989, 3, 29),
                _nannyAdress = "רחוב הרב קוק 8, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 3,
                _nannyPhone = 0521001001,
                _maxMonthAge = 18,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = true,
                _rateByHour = 10,
                _rateByMonth = 900,
                _isTamatNanny = true,
                _workDays = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1, 7, 0, 0),
                    new DateTime(01,01,1,7,15,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8,15,0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,14,0,0),
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,0,0,0),
                },
                //_recommendation = recomandactions[2],

            };
            Nanny Shifi_Aizen = new Nanny
            {
                _nannyID = idNannyArray[19],
                _nannyFname = "שיפי",
                _nannyLname = "אייזן",
                _nannyBirth = new DateTime(1980, 5, 19),
                _nannyAdress = "רחוב הרב שלום שבזי 12, ירושלים",
                _isElevator = true,
                _floor = 2,
                _yearsOfExp = 3,
                _nannyPhone = 0529344513,
                _maxMonthAge = 15,
                _minMonthAge = 3,
                _maxamountChildren = 8,
                _acceptByHour = false,
                _rateByMonth = 900,
                _isTamatNanny = false,
                _workDays = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,7, 15, 0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,7, 0,0),
                    new DateTime(01,01,1,7, 0,0),
                    new DateTime(01,01,1,7, 30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,14, 0,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(01,01,1,0,0,0),
                },
                //_recommendation = recomandactions[0],
            };
            try
            {
                dal.addNanny(malki_fishman);
                dal.addNanny(Moria_schneider);
                dal.addNanny(Ayala_Zehavi);
                dal.addNanny(Yafi_Shtain);
                dal.addNanny(Hila_Sharabi);
                dal.addNanny(Adi_Shushan);
                dal.addNanny(Chavi_Horen);
                dal.addNanny(Shifi_Aizen);
                dal.addNanny(Tsipi_Hotoveli);
                dal.addNanny(Gila_Elmagor);
                dal.addNanny(Miryam_BenHamu);
                dal.addNanny(lea_Gans);
                dal.addNanny(Batya_Adler);
                dal.addNanny(Chani_Yosef);
                dal.addNanny(Avigail_Kuk);
                dal.addNanny(Mehira_Shulman);
                dal.addNanny(batSheva_Choen);
                dal.addNanny(noa_Karlibach);
                dal.addNanny(Diti_Farkash);
                dal.addNanny(Elisheva_Shaked);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Initilize & addtion to list 21 Mothers
        /// </summary>
        /// 

        void MotherInitilize()
        {

            Mother Bracha_Polak = new Mother
            {
                _momID = idMotherArray[0],
                _momFname = "ברכה",
                _momLname = "פולק",
                _momAdress = "HaRav Herzog St 12, Jerusalem",
                _momPhone = 0526874352,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, false, true, false, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 30, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },

                // nothMom = "",

            };
            Mother Oshrat_Levi = new Mother
            {
                _momID = idMotherArray[1],
                _momFname = "אושרת",
                _momLname = "לוי",
                _momAdress = "Ha-'va'ad haleumi St 21,Jerusalem",
                _momPhone = 0526943451,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { false, true, true, true, true, true },
                _startHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,9,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,17,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(01,01,1,12,0,0),
                },
                // nothMom = "",
            };
            Mother Ayelt_Shaked = new Mother
            {
                _momID = idMotherArray[2],
                _momFname = "איילת",
                _momLname = "שקד",
                _momAdress = "Shakhal St 23,Jerusalem",
                _momPhone = 0521234566,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 15, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,13,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(),
                },
                // nothMom = "",
            };
            Mother Gilat_Benet = new Mother
            {
                _momID = idMotherArray[3],
                _momFname = "גילת",
                _momLname = "בנט",
                _momAdress = "HaMem Gimel St 4, Jerusalem",
                _momPhone = 0527668451,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 15, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,16,0,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,14, 0,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(),
                },
                // nothMom = "",
            };
            Mother Esti_Kopshitz = new Mother
            {
                _momID = idMotherArray[4],
                _momFname = "ברכה",
                _momLname = "קופביץ",
                _momAdress = "Haham Shmuel Bruchim St 5, Jerusalem",
                _momPhone = 0523154634,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,7, 45, 0),
                    new DateTime(01,01,1,7,45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,15,45,0),
                    new DateTime(01,01,1,15, 45,0),
                    new DateTime(01,01,1,15, 45,0),
                    new DateTime(01,01,1,15, 45,0),
                    new DateTime(),
                },
                // nothMom = "",
            };
            Mother Irena_Gavrielov = new Mother
            {
                _momID = idMotherArray[5],
                _momFname = "אירנה",
                _momLname = "גבריאלוב",
                _momAdress = "Arzei ha-Bira St 6, Jerusalem",
                _momPhone = 0523756345,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, false, true, true, false, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 15, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 15,0),
                    new DateTime(01,01,1,8, 15,0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,15,0),
                    new DateTime(),
                    new DateTime(01,01,1,14, 15,0),
                    new DateTime(01,01,1,14, 15,0),
                    new DateTime(),
                    new DateTime(01,01,1,12,0,0),
                },
                // nothMom = "",
            };
            Mother Tovi_Shachak = new Mother
            {
                _momID = idMotherArray[6],
                _momFname = "טובי",
                _momLname = "שחק",
                _momAdress = "Kav Venaki St 6, Jerusalem",
                _momPhone = 0527156743,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, true, true, true, true, true },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,9, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,13,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,12,30,0),
                },
                // nothMom = "",
            };
            Mother Sheindi_Lider = new Mother
            {
                _momID = idMotherArray[7],
                _momFname = "דקלה",
                _momLname = "שובי",
                _momAdress = "Yosef Ben Matityahu St 28, Jerusalem",
                _momPhone = 0548456654,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, true, true, true, false, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(01,01,1,8, 15,0),
                    new DateTime(),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(),
                    new DateTime(),
                },

                // nothMom = "",
            };
            Mother Beili_Yudkevitz = new Mother
            {
                _momID = idMotherArray[8],
                _momFname = "שולה",
                _momLname = "יודקביץ",
                _momAdress = "HaRav Shalom Shabazi St 4, Jerusalem",
                _momPhone = 0509998881,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, false, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,7, 45, 0),
                    new DateTime(),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(01,01,1,15, 30,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                // // nothMom = "",
            };
            Mother Malki_Orbach = new Mother
            {
                _momID = idMotherArray[9],
                _momFname = "מלכי",
                _momLname = "אורבך",
                _momAdress = "HaRav Kuk St 12, Jerusalem",
                _momPhone = 0571114444,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, false, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,8, 30,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                // // nothMom = "",
            };
            Mother Yuti_Ashlag = new Mother
            {
                _momID = idMotherArray[10],
                _momFname = "יעל",
                _momLname = "קליין",
                _momAdress = "HaRav Reines St 5, Jerusalem",
                _momPhone = 0528989897,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },

                // // nothMom = "",
            };
            Mother Sara_Landau = new Mother
            {
                _momID = idMotherArray[11],
                _momFname = "שרה",
                _momLname = "לנדאו",
                _momAdress = "Sderot Sarei Israel St 2 Jerusalem",
                _momPhone = 0527616509,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { false, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,7, 30,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                // nothMom = "",
            };
            Mother Ruti_salomon = new Mother
            {
                _momID = idMotherArray[12],
                _momFname = "רותי",
                _momLname = "סלמון",
                _momAdress = "Jaffa St 8, Jerusalem",
                _momPhone = 0543331234,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, false, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                // nothMom = "",
            };
            Mother Chani_Stern = new Mother
            {
                _momID = idMotherArray[13],
                _momFname = "חני",
                _momLname = "שטרן",
                _momAdress = "Yafo St 222, Jerusalem",
                _momPhone = 0525555111,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, true, true, true, false, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,14, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(),
                    new DateTime(),
                },
                // nothMom = "",
            };
            Mother Aliza_Sorotzkin = new Mother
            {
                _momID = idMotherArray[14],
                _momFname = "עליזה",
                _momLname = "סורוצקין",
                _momAdress = "Ha-Nevi'im St 4, Jerusalem",
                _momPhone = 0526870003,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { false, true, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                // nothMom = "",
            };
            Mother Mina_Berkovitz = new Mother
            {
                _momID = idMotherArray[15],
                _momFname = "מרב",
                _momLname = "רייכנר",
                _momAdress = "Ha-Amarkalim St 4, Jerusalem",
                _momPhone = 056754312,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, false, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 15,0),
                    new DateTime(01,01,1,7, 30,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                // nothMom = "",
            };
            Mother Shani_Hovav = new Mother
            {
                _momID = idMotherArray[16],
                _momFname = "שני",
                _momLname = "חובב",
                _momAdress = "Sulam Ya'akov St 32, Jerusalem",
                _momPhone = 0520909091,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { false, true, false, true, true, true },
                _startHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8,0,0),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,14, 30,0),
                    new DateTime(01,01,1,12,0,0),
                },
                // nothMom = "",
            };
            Mother Esti_Lerner = new Mother
            {
                _momID = idMotherArray[17],
                _momFname = "רחל",
                _momLname = "אלבז",
                _momAdress = "Binyamin Minz St 7, Jerusalem",
                _momPhone = 0522020202,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, false, true, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,15, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                // nothMom = "",
            };
            Mother Rochi_Zaltz = new Mother
            {
                _momID = idMotherArray[18],
                _momFname = "רחל",
                _momLname = "זקב",
                _momAdress = "Panim Meirot St 14, Jerusalem",
                _momPhone = 0521313132,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, true, false, true, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 15, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 45,0),
                    new DateTime(01,01,1,7, 45,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,13,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(),
                    new DateTime(01,01,1,16, 0,0),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
                // nothMom = "",
            };
            Mother Faigi_toyb = new Mother
            {
                _momID = idMotherArray[19],
                _momFname = "נינט",
                _momLname = "טייב",
                _momAdress = "Ha-Yehudim St 2, Jerusalem",
                _momPhone = 0521001001,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, true, true, false, true, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 30, 0),
                    new DateTime(01,01,1,8,0,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,13,30,0),
                    new DateTime(01,01,1,12,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(),
                    new DateTime(01,01,1,13, 30,0),
                    new DateTime(),
                },
            };
            Mother Shiri_Hochman = new Mother
            {
                _momID = idMotherArray[20],
                _momFname = "שירי",
                _momLname = "הוכמן",
                _momAdress = "Me'a She'arim St 1, Jerusalem",
                _momPhone = 0521818181,
                _locationOfNanny = "Shakhal St 23,Jerusalem",
                _daysRequestMom = new bool[6] { true, true, true, true, false, false },
                _startHour = new DateTime[6]
                {
                    new DateTime(01, 01, 1,8, 0, 0),
                    new DateTime(01,01,1,8,30,0),
                    new DateTime(01,01,1,8, 0,0),
                    new DateTime(01,01,1,8, 30,0),
                    new DateTime(),
                    new DateTime(),
                },
                _endHour = new DateTime[6]
                {
                    new DateTime(01,01,1,14,30,0),
                    new DateTime(01,01,1,15,30,0),
                    new DateTime(01,01,1,12, 30,0),
                    new DateTime(01,01,1,16, 30,0),
                    new DateTime(),
                    new DateTime(),
                },
                // nothMom = "",
            };


            try
            {
                dal.addMother(Bracha_Polak);
                dal.addMother(Shiri_Hochman);
                dal.addMother(Rochi_Zaltz);
                dal.addMother(Faigi_toyb);
                dal.addMother(Esti_Lerner);
                dal.addMother(Shani_Hovav);
                dal.addMother(Mina_Berkovitz);
                dal.addMother(Aliza_Sorotzkin);
                dal.addMother(Chani_Stern);
                dal.addMother(Ruti_salomon);
                dal.addMother(Sara_Landau);
                dal.addMother(Yuti_Ashlag);
                dal.addMother(Malki_Orbach);
                dal.addMother(Beili_Yudkevitz);
                dal.addMother(Bracha_Polak);
                dal.addMother(Ayelt_Shaked);
                dal.addMother(Oshrat_Levi);
                dal.addMother(Gilat_Benet);
                dal.addMother(Esti_Kopshitz);
                dal.addMother(Tovi_Shachak);
                dal.addMother(Irena_Gavrielov);
                dal.addMother(Sheindi_Lider);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }

        /// <summary>
        /// Initilize & addtion to list 30 Childs
        /// </summary>
        void ChildInitilize()
        {
            Child nadav = new Child
            {
                _childID = _childIDArray[0],
                _momID = idMotherArray[0],
                _childFname = "נדב",
                _birthday = new DateTime(2017, 8, 26),
                _isSpecialNeed = false,
            };

            Child moty = new Child
            {
                _childID = _childIDArray[1],
                _momID = idMotherArray[1],
                _childFname = "מוטי",
                _birthday = new DateTime(2017, 9, 8),
                _isSpecialNeed = false,
            };

            Child eti = new Child
            {
                _childID = _childIDArray[2],
                _momID = idMotherArray[2],
                _childFname = "אתי",
                _birthday = new DateTime(2017, 5, 29),
                _isSpecialNeed = false,
            };

            Child miri = new Child
            {
                _childID = _childIDArray[3],
                _momID = idMotherArray[3],
                _childFname = "הלל",
                _birthday = new DateTime(2017, 1, 22),
                _isSpecialNeed = false,
            };

            Child david = new Child
            {
                _childID = _childIDArray[4],
                _momID = idMotherArray[4],
                _childFname = "דוד",
                _birthday = new DateTime(2017, 2, 9),
                _isSpecialNeed = false,
            };

            Child yael = new Child
            {
                _childID = _childIDArray[5],
                _momID = idMotherArray[4],
                _childFname = "יעל",
                _birthday = new DateTime(2017, 2, 24),
                _isSpecialNeed = false,
            };

            Child naama = new Child
            {
                _childID = _childIDArray[6],
                _momID = idMotherArray[5],
                _childFname = "נעמה",
                _birthday = new DateTime(2017, 3, 1),
                _isSpecialNeed = false,
            };

            Child hila = new Child
            {
                _childID = _childIDArray[7],
                _momID = idMotherArray[6],
                _childFname = "הילה",
                _birthday = new DateTime(2017, 2, 2),
                _isSpecialNeed = false,
            };

            Child michal = new Child
            {
                _childID = _childIDArray[8],
                _momID = idMotherArray[7],
                _childFname = "מיכל",
                _birthday = new DateTime(2017, 5, 29),
                _isSpecialNeed = false,
            };

            Child adi = new Child
            {
                _childID = _childIDArray[9],
                _momID = idMotherArray[7],
                _childFname = "עדי ",
                _birthday = new DateTime(2017, 1, 9),
                _isSpecialNeed = false,
            };

            Child reut = new Child
            {
                _childID = _childIDArray[10],
                _momID = idMotherArray[7],
                _childFname = "רעות",
                _birthday = new DateTime(2017, 4, 2),
                _isSpecialNeed = false,
            };

            Child efrat = new Child
            {
                _childID = _childIDArray[11],
                _momID = idMotherArray[8],
                _childFname = "אפי",
                _birthday = new DateTime(2017, 4, 12),
                _isSpecialNeed = false,
            };

            Child noa = new Child
            {
                _childID = _childIDArray[12],
                _momID = idMotherArray[8],
                _childFname = "נעה",
                _birthday = new DateTime(2017, 5, 1),
                _isSpecialNeed = false,
            };

            Child shira = new Child
            {
                _childID = _childIDArray[13],
                _momID = idMotherArray[9],
                _childFname = "שירה",
                _birthday = new DateTime(2017, 5, 29),
                _isSpecialNeed = false,
            };

            Child Moriya = new Child
            {
                _childID = _childIDArray[14],
                _momID = idMotherArray[10],
                _childFname = "מוריה",
                _birthday = new DateTime(2017, 6, 2),
                _isSpecialNeed = false,
            };

            Child sari = new Child
            {
                _childID = _childIDArray[15],
                _momID = idMotherArray[10],
                _childFname = "שרי",
                _birthday = new DateTime(2017, 6, 9),
                _isSpecialNeed = false,
            };

            Child yehuda = new Child
            {
                _childID = _childIDArray[16],
                _momID = idMotherArray[11],
                _childFname = "יהודה",
                _birthday = new DateTime(2017, 6, 29),
                _isSpecialNeed = false,
            };

            Child itsik = new Child
            {
                _childID = _childIDArray[17],
                _momID = idMotherArray[12],
                _childFname = "איציק",
                _birthday = new DateTime(2017, 8, 11),
                _isSpecialNeed = false,
            };

            Child pinchas = new Child
            {
                _childID = _childIDArray[18],
                _momID = idMotherArray[13],
                _childFname = "פנחס",
                _birthday = new DateTime(2017, 7, 3),
                _isSpecialNeed = false,
            };

            Child yanki = new Child
            {
                _childID = _childIDArray[19],
                _momID = idMotherArray[14],
                _childFname = "אורי",
                _birthday = new DateTime(2017, 6, 2),
                _isSpecialNeed = false,
            };

            Child eliyau = new Child
            {
                _childID = _childIDArray[20],
                _momID = idMotherArray[15],
                _childFname = "אליהו",
                _birthday = new DateTime(2017, 6, 2),
                _isSpecialNeed = false,
            };

            Child eli = new Child
            {
                _childID = _childIDArray[21],
                _momID = idMotherArray[15],
                _childFname = "אלי",
                _birthday = new DateTime(2017, 9, 9),
                _isSpecialNeed = false,
            };

            Child yosef = new Child
            {
                _childID = _childIDArray[22],
                _momID = idMotherArray[16],
                _childFname = "יוסף",
                _birthday = new DateTime(2017, 10, 22),
                _isSpecialNeed = false,
            };

            Child ari = new Child
            {
                _childID = _childIDArray[23],
                _momID = idMotherArray[17],
                _childFname = "ארי",
                _birthday = new DateTime(2017, 11, 29),
                _isSpecialNeed = false,
            };

            Child shuki = new Child
            {
                _childID = _childIDArray[24],
                _momID = idMotherArray[17],
                _childFname = "שוקי",
                _birthday = new DateTime(2017, 12, 2),
                _isSpecialNeed = false,
            };

            Child itamar = new Child
            {
                _childID = _childIDArray[25],
                _momID = idMotherArray[17],
                _childFname = "איתמר",
                _birthday = new DateTime(2017, 5, 2),
                _isSpecialNeed = false,
            };

            Child yoni = new Child
            {
                _childID = _childIDArray[26],
                _momID = idMotherArray[18],
                _childFname = "יוני",
                _birthday = new DateTime(2017, 10, 14),
                _isSpecialNeed = false,
            };

            Child moishi = new Child
            {
                _childID = _childIDArray[27],
                _momID = idMotherArray[19],
                _childFname = "מויישי",
                _birthday = new DateTime(2017, 3, 19),
                _isSpecialNeed = false,
            };

            Child avreimi = new Child
            {
                _childID = _childIDArray[28],
                _momID = idMotherArray[19],
                _childFname = "אבריימי",
                _birthday = new DateTime(2017, 11, 9),
                _isSpecialNeed = false,
            };

            Child yosi = new Child
            {
                _childID = _childIDArray[29],
                _momID = idMotherArray[20],
                _childFname = "יוסי",
                _birthday = new DateTime(2017, 12, 2),
                _isSpecialNeed = false,
            };

            try
            {
                dal.addChild(nadav);
                dal.addChild(moty);
                dal.addChild(eli);
                dal.addChild(yael);
                dal.addChild(yanki);
                dal.addChild(yehuda);
                dal.addChild(yoni);
                dal.addChild(yosef);
                dal.addChild(yosi);
                dal.addChild(michal);
                dal.addChild(miri);
                dal.addChild(moishi);
                dal.addChild(Moriya);
                dal.addChild(naama);
                dal.addChild(noa);
                dal.addChild(sari);
                dal.addChild(shira);
                dal.addChild(shuki);
                dal.addChild(efrat);
                dal.addChild(eliyau);
                dal.addChild(hila);
                dal.addChild(pinchas);
                dal.addChild(itsik);
                dal.addChild(itamar);
                dal.addChild(eti);
                dal.addChild(adi);
                dal.addChild(david);
                dal.addChild(ari);
                dal.addChild(avreimi);
                dal.addChild(reut);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}