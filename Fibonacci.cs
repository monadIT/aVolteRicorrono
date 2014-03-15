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

static public class Fibonacci
{
	static public int fibonacci(int n)
	{
        int risultato = 1;
        int[] ultimi2 = {1,1};

        while (n > 2)
        {
            risultato = ultimi2[1] + ultimi2[0];
            ultimi2[0] = ultimi2[1];
            ultimi2[1] = risultato;
            --n;
        }
        return risultato;
	}
}
