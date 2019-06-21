module DiffieHellman

open System.Numerics;
open System.Security.Cryptography;

let generator = RNGCryptoServiceProvider.Create()

let getRandom (primeP :BigInteger) = 
    let value = Array.zeroCreate(primeP.GetByteCount(true))
    generator.GetBytes value
    let possitiveNumber = value.[0] &&& (byte)0X7F
    Array.set value 0 possitiveNumber
    new BigInteger (value)

let BigOne = new BigInteger(1)

let checkRange primeP value =
    value > BigOne && value < primeP

let rec generate primeP =
    let check = checkRange primeP
    let value = getRandom primeP

    match check value with
    | true -> value
    | false -> generate primeP

let privateKey primeP = 
    generate primeP

let publicKey (primeP :BigInteger) (primeG :BigInteger) (privateKey :BigInteger) = 
    BigInteger.ModPow(primeG,privateKey,primeP)
    

let secret primeP publicKey privateKey = 
    BigInteger.ModPow(publicKey,privateKey,primeP)