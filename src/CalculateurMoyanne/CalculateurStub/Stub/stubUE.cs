﻿using ClassCalculateurMoyenne;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubCalculateur.Stub
{
    public class stubUE
    {
        private List<UE> listUE = new List<UE>();
        private List<Matiere> mat = new List<Matiere>();
        public async Task<bool> Add(UE data)
        {
            if (data != null)
            {
                listUE.Add(data);
                return true;
            }
            return false;
        }




        public async Task<bool> Delete(UE data)
        {
            if (data != null)
            {
                listUE.Remove(data);
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<UE>> GetAll()
        {

            return listUE;
        }
        public async Task<bool> Update(UE data)
        {
            if (data != null)
            {

                int index = listUE.FindIndex(x => x.Matieres == data.Matieres);
                listUE[index] = data;
            }
            return false;
        }

       
        public IEnumerable<UE> GetAllMatiere(int n = 10)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mat.Add(new Matiere(""));
                }
                listUE.Add(new UE("f"));
                mat.Clear();
            }
            return listUE;




        }
    }
}