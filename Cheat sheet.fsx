// I) Types

// I.1) types primitifs

let i = 5 // int
let d = 3.2 // float
let m = 4.3m // decimal
let s = "toto" // string
let b = true // bool
let l = [1; 2] // int list (list est une liste chainée immuable)
let l2 =  [1..10] // int list de 1 à 10
let l3 = [1..4] @ [i] @ [6..10] // int list de 1 à 10

s = "tutu" // false car = est l'opérateur d'égalité

let s' = "tutu"
let ``Nom de variable avec des espaces`` = "bonjour"

let i': int = 7

let unit' = () // équivalent de void

// Unités de mesure
type [<Measure>] km
type [<Measure>] h

let distance = 300.0<km>
let duree = 2.0<h>

// distance + duree // ne compile pas

let vitesse = distance / duree // = 150.0<km/h>


// I.2) Produits (tuples et records)

type PointTuple = int * int
let pointTuple = 1, 3
let x, y = pointTuple // x = 1, y = 3
let x', _ = pointTuple // _ = on s'en fout

type PointRecord = { 
    x: int
    y: int
} // ou type Point = { x: int; y: int }

let point = { 
    x = 1
    y = 3
} // ou let point = { x = 1; y = 3 }

let { x = xRecord; y = _ } = point

// I.3) Sommes (unions)

type Booleen = Vrai | Faux

type Shape =
    | Point
    | Circle of int
    | Square of int
    | Rectangle of int * int
    
let p = Point
let circle = Circle 3
let rectangle = Rectangle (2, 5)

// Équivalent de Nullable<'a>
(*
type Option<'a> =
    | Some of 'a
    | None
*)
let some1: Option<int> = Some 1
let none: int option = None

// Remplace les exceptions
type Result<'a, 'error> =
    | Ok of 'a
    | Error of 'error