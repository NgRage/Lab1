open System

//Генератор степеней двойки
let Step2 N = 
    let list = [for i in 0..N-1 -> 2.0**i]
    list

//Проверка ввода
let rec Read () =
    printf "Введите натруальное число: "
    let input = Console.ReadLine()
    let succes, n = Int32.TryParse(input)

    if succes && n > 0  then
        n
    else
        printfn "Ошибка: Введенное число должно быть натуральным"
        Read ()
        

[<EntryPoint>]
let main args =
    let Num = Read ()
    
    let list = Step2 Num
    printf "Первые %i чисел, являющиеся степенями двойки %A" Num list
    0
