(*    Copyright 2014 Andrea Boccaccio - andrea@monad.it

      This program is free software: you can redistribute it and/or modify
      it under the terms of the GNU General Public License as published by
      the Free Software Foundation, either version 3 of the License, or
      (at your option) any later version.

      This program is distributed in the hope that it will be useful,
      but WITHOUT ANY WARRANTY; without even the implied warranty of
      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      GNU General Public License for more details.

      You should have received a copy of the GNU General Public License
      along with this program.  If not, see <http://www.gnu.org/licenses/>. *)

type ('etichetta,'contenuto) mioAlbero =
Vuoto
|Foglia of 'etichetta * 'contenuto
|Nodo of 'etichetta * ('etichetta,'contenuto) mioAlbero list;;

let rec visProfPreOrd f a = match a with
Vuoto | Foglia -> [f a]
| Nodo(_,figli) -> List.fold_left (fun x y -> List.append x (visProfPreOrd f y)) [f a] figli;;

let rec visProfPreOrd f a = match a with
Vuoto | Foglia(_,_) -> [f a]
| Nodo(_,figli) -> List.fold_left (fun x y -> List.append x (visProfPreOrd f y)) [f a] figli;;

let f01 = Foglia("Foglia 01",1);;

let f02 = Foglia("Foglia 02",2);;

let f03 = Foglia("Foglia 03",3);;

let f04 = Foglia("Foglia 04",4);;

let n01 = Nodo("Nodo 01",[f02]);;

let n02 = Nodo("Nodo 02",[]);;

let n03 = Nodo("Nodo 03",[f03;f04]);;

let n04 = Nodo("Nodo 04",[n03]);;

let r = Nodo("Radice",[n04;f01;n01;n02]);;

visProfPreOrd (fun x -> x) r;;

