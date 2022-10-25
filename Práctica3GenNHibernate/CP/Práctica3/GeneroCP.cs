
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using Práctica3GenNHibernate.Exceptions;
using Práctica3GenNHibernate.EN.Práctica3;
using Práctica3GenNHibernate.CAD.Práctica3;
using Práctica3GenNHibernate.CEN.Práctica3;



namespace Práctica3GenNHibernate.CP.Práctica3
{
public partial class GeneroCP : BasicCP
{
public GeneroCP() : base ()
{
}

public GeneroCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
