open System

//Свой тип данных
type Complex = {Re: float; Im: float}

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
    let s1 = {Re = 5.0; Im = 2.0}
    let s2 = {Re = 2.0; Im = -1.0}
    
    let sum = add s1 s2
    let diff = sub s1 s2
    let prod = mul s1 s2
    let atti = div s1 s2
    let step = pow s1 2

    printfn "Первое число: %.1f + %.1fi" s1.Re s1.Im
    printfn "Второе число: %.1f + %.1fi" s2.Re s2.Im
    printfn "Сумма: %.1f + %.1fi" sum.Re sum.Im
    printfn "Разнгсть: %.1f + %.1fi" diff.Re diff.Im
    printfn "Произведение: %.1f + %.1fi" prod.Re prod.Im
    printfn "Частное: %.1f + %.1fi" atti.Re atti.Im
    printfn "Возведение первого числа во вторую степень: %.1f + %.1fi" step.Re step.Im
    0