module NbJson

open FSharp.Json

let private sConfig = JsonConfig.create (allowUntyped = true, unformatted = true)
let private dConfig = JsonConfig.create (allowUntyped = true)

let serialize x = Json.serializeEx sConfig x
let deserialize json = Json.deserializeEx dConfig json

let tryDeserialize json =
    try deserialize json |> Ok
    with ex -> Error ex.Message

module Camel =
    let private sConfig =
        JsonConfig.create (allowUntyped = true, unformatted = true, jsonFieldNaming = Json.lowerCamelCase)
    let private dConfig =
        JsonConfig.create (allowUntyped = true, jsonFieldNaming = Json.lowerCamelCase)

    let serialize x = Json.serializeEx sConfig x
    let deserialize json = Json.deserializeEx dConfig json

    let tryDeserialize json =
        try deserialize json |> Ok
        with ex -> Error ex.Message
