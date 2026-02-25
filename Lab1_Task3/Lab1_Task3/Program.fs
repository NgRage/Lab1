open System

//Re - действительная часть; Im - мнимая часть)
type Complex = {Re: float; Im: float}

let rec Read_Float () =
    let input = Console.ReadLine()
    let succes, n = Double.TryParse(input)

    if succes then
        n
    else
        printf "Ошибка: Должно быть введено число. Повторите ввод:"
        Read_Float ()

let rec Read_Natural () =
    let input = Console.ReadLine()
    let succes, n = Int32.TryParse(input)

    if succes then
        n
    else
        printf "Ошибка: Должно быть введено число. Повторите ввод:"
        Read_Natural ()

//(a+bi) + (c+di) = (a+c) + (b+d)i
let add s1 s2 = 
    {Re = s1.Re + s2.Re;
     Im = s1.Im + s2.Im}

//(a+bi) - (c+di) = (a-c) + (b-d)i
let sub s1 s2 =
    {Re = s1.Re - s2.Re;
     Im = s1.Im - s2.Im}

//(a+bi) * (c+di) = (ac-bd) + (ad+bc)i
let mul s1 s2 =
    {Re = s1.Re * s2.Re - s1.Im * s2.Im;
     Im = s1.Re * s2.Im + s1.Im * s2.Re}

//(a+bi) / (c+di) = ((ac+bd) / c**2 + d**2) + ((bc-ad) / c**2 + d**2)i
let div s1 s2 = 
    let den = s2.Re**2. + s2.Im**2.
    
    {Re = (s1.Re * s2.Re + s1.Im * s2.Im) / den;
     Im = (s1.Im * s2.Re - s1.Re * s2.Im) / den}

//r^n * (cos(n*φ) + i*sin(n*φ))
let pow s n = 
    let r = sqrt(s.Re**2. + s.Im**2)
    let φ = atan2 s.Im s.Re
    let rn = r ** (float n)

    { Re = rn * cos(float n * φ);
      Im = rn * sin(float n * φ)}


[<EntryPoint>]
let main arg =
    printf "Введите действительну часть первого числа: "
    let s1_Re = Read_Float()
    printf "Введите мнимую часть первого числа: "
    let s1_Im = Read_Float()
    let s1 = {Re = s1_Re; Im = s1_Im}

    printf"Выберите действие: 1 - Сумма, 2 - Разность, 3 - Произведение, 4 - Деление, 5 - Возведение в степень: "
    let operation = Read_Natural()

    let s2, n =
        if operation = 5 then
            printf "Введите степень, в которую нужно возвести: "
            let step = Read_Natural()
            { Re = 0.0; Im = 0.0 }, step
        else if operation >= 1 &&  operation <= 4 then
            printf "Введите действительну часть второго числа: "
            let s2_Re = Read_Float()
            printf "Введите мнимую часть второго числа: "
            let s2_Im = Read_Float()
            {Re = s2_Re; Im = s2_Im}, 0
        else
            failwith "Некоректный выбор операции"

    let result =
        match operation with 
            | 1 -> add s1 s2
            | 2 -> sub s1 s2
            | 3 -> mul s1 s2
            | 4 -> div s1 s2
            | 5 -> pow s1 n
    
    if result.Im >= 0 then
        printfn "Результат: %.1f + %.1fi" result.Re result.Im
    else
        printfn "Результат: %.1f - %.1fi" result.Re (abs result.Im)

    0