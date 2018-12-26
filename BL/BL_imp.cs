using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class BL_imp : IBL
    {
        Dal_imp effector=new Dal_imp();
         void add_tester(int _id, string _lastname, string _firstname, DateTime _date_of_birth, gender _Gender, int _phone, Address _address, float _expirence, int _max_testPerWeek, vehicle _tester_expertise,int _max_way)
            {
            DateTime Temp;
            Temp=DateTime.now-_date_of_birth;
            if (Temp.Year>=40)
                {
                throw new my_exception("Tetser must be  at least 40 years old.");
                }
            effector.add_tester( _id,  _lastname,  _firstname,  _date_of_birth,  _Gender,  _phone,  _address,  _expirence,  _max_testPerWeek,  _tester_expertise,_max_way);

            }
      
    }
}
