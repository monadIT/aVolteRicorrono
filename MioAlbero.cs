//      Copyright 2014 Andrea Boccaccio - andrea@monad.it

//      This program is free software: you can redistribute it and/or modify
//      it under the terms of the GNU General Public License as published by
//      the Free Software Foundation, either version 3 of the License, or
//      (at your option) any later version.

//      This program is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//      GNU General Public License for more details.

//      You should have received a copy of the GNU General Public License
//      along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;

abstract public class MioAlbero<T>
{
    public T Etichetta { get; set; }

    abstract public List<U> visProfPreOrd<U>(Func<MioAlbero<T>, U> f);
}

public class Foglia<T,Z> : MioAlbero<T>
{
    public Z Contenuto { get; set; }

    override public List<U> visProfPreOrd<U>(Func<MioAlbero<T>, U> f)
    {
        return new[] { f(this) }.ToList();
    }
}

public class Nodo<T> : MioAlbero<T>
{
    public IList<MioAlbero<T>> Figli { get; set; }

    public Nodo<T> aggiungiFiglio(MioAlbero<T> a)
    {
        this.Figli.Add(a);
        return this;
    }

    override public List<U> visProfPreOrd<U>(Func<MioAlbero<T>, U> f)
    {
        var stackEsplicito = new Stack<MioAlbero<T>>();
        List<U> ret = new List<U>();

        stackEsplicito.Push(this);
        while (stackEsplicito.Count > 0)
        {
            var nodoCorrente = stackEsplicito.Pop();
            var pi = nodoCorrente.GetType().GetProperty("Figli");

            ret.Add(f(nodoCorrente));
            if (pi != null)
            {
                var figliNodoCorrente = (IList<MioAlbero<T>>)pi.GetValue(nodoCorrente);
                for (var i = (figliNodoCorrente.Count - 1); i >= 0;  --i)
                {
                    stackEsplicito.Push(figliNodoCorrente[i]);
                }
            }
        }
        return ret;
    }

}
