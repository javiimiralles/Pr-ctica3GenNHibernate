
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Práctica3GenNHibernate.Exceptions;
using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.CAD.Práctica3;


/*PROTECTED REGION ID(usingPráctica3GenNHibernate.CEN.Práctica3_Cliente_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace Práctica3GenNHibernate.CEN.Práctica3
{
public partial class ClienteCEN
{
public string Login (string p_Cliente_OID, string p_pass)
{
        /*PROTECTED REGION ID(Práctica3GenNHibernate.CEN.Práctica3_Cliente_login) ENABLED START*/
        string result = null;
        IList<ClienteEN> listaEn = DameClientesPorEmail(p_Cliente_OID);

        if(listaEn.Count > 0)
        {
            ClienteEN en = listaEn[0];
            if (en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                    result = this.GetToken (en.Email);
        }

        return result;
        /*PROTECTED REGION END*/
}
}
}
