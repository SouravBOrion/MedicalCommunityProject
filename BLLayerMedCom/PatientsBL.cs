﻿using BOLayerMedCom;
using DALayerMedCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BLLayerMedCom
{
    public class PatientsBL
    {
        public UnitOfWork uw;
        public int TotalPatients{
            get{
                return uw.PatientRepository.Get().Count();
            }
            private set
            {

            }

            }

         public PatientsBL(DbContext context)
        {
            uw = new UnitOfWork(context);
        }



        public List<Patient> getPatientList(int superVisorID)
        {
            var filteredPatients=uw.PatientRepository.Get(filter: d => d.Supervisor==superVisorID);
            return filteredPatients.ToList();

        }

        public bool insertPatient(Patient patient)
        {
            uw.PatientRepository.Insert(patient);
            uw.Save();
            return true;
        }

    }
}
