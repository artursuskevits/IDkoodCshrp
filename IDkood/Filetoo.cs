using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDkood
{
    public class Filetoo
    {


        public static void Saveheaisikukood(List<IdCode> esimine, List<IdCode> teine)
        {
            using (StreamWriter file = new StreamWriter(@"..\..\..\heaidi.txt"))
            {
                foreach (IdCode element in esimine)
                {
                    file.WriteLine("{0}", element.IDCODE);
                }
            }
            using (StreamWriter file = new StreamWriter(@"..\..\..\eiheaidid.txt"))
            {
                foreach (IdCode element in teine)
                {
                    file.WriteLine("{0}", element.IDCODE);
                }
            }

          
        }
        public static (List<IdCode>, List<IdCode>) create_2_dictionary(List<IdCode> esimine, List<IdCode> teine)
        {
            using (StreamReader sr1 = new StreamReader(@"..\..\..\heaidi.txt"))
            using (StreamReader sr2 = new StreamReader(@"..\..\..\eiheaidid.txt"))
            {

                string line;
                while ((line = sr1.ReadLine()) != null)
                {
                    esimine.Add(new IdCode(line));

                }
                while ((line = sr2.ReadLine()) != null)
                {
                    teine.Add(new IdCode(line));

                }
                return (esimine, teine);
            }
        }

        public static (List<IdCode>, List<IdCode>) clear_2_dictionary(List<IdCode> esimine, List<IdCode> teine)
        {
            esimine.Clear();
            teine.Clear();
            
            return (esimine, teine);
        }
        
    }

}  
