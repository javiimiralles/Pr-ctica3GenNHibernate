using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using Pr�ctica3GenNHibernate.CAD.Pr�ctica3;

namespace Pr�ctica3GenNHibernate.Controllers
{
    public class BasicController: Controller
    {
    protected ISession session;

    protected BasicController()
    {
    }

    protected void SessionInitialize ()
    {
            if (session == null) {
                    session = NHibernateHelper.OpenSession ();
            }
    }


    protected void SessionClose ()
    {
            if (session != null && session.IsOpen) {
                    session.Close ();
                    session.Dispose ();
                    session = null;
            }
    }
    }
}
