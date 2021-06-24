using System;

namespace tpConnecte201b
{
    public class Employe
    {
        private int code;
        private string nom;
        private string prenom;

        public int Code
        {
            set {
                if (value > 0)
                    code = value;
                else
                    throw new Exception("Code doit etre positif");
            }
            get { return code; }
        }
        public Employe()
        {

        }
        public Employe(int code, string nom, string prenom) {
            this.nom = nom;
            this.code = code;
            this.prenom = prenom;
        
        }
        public override string ToString()
        {
            return code+"-"+nom+"-"+prenom;
        }

    }
}
