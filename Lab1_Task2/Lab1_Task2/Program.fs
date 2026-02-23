open System

//Поиск первой цифры
let rec First_Digit N = 
    if N < 10 then
        N
    else
        First_Digit(N/10)

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

    let first = First_Digit Num
    printf "Первая цифра числа %i: %i" Num first
    0
