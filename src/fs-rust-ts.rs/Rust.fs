module Rust

open System.Collections.Generic
open Fable.Core
open Shared
open fsil_rust
open bindings.wasm_bindgen

Fable.Core.Rust.import "wasm_bindgen::prelude::*" ""

[<Emit("format!(\"{:?}\",$0)")>]
let inline format(s: obj) : string = nativeOnly

let api: WasmApi =
    { new WasmApi with

        member _.log_something_with_callback
            (input: string)
            (callback: JSFunction1<string, int>)
            : unit =
            
            let _ =
                callback.call1 (
                    Ref.from JsValue.NULL,
                    Ref.from (JsValue.from_str (str.from input))
                )


            let response =
                callback.call1 (
                    Ref.from JsValue.NULL,
                    Ref.from (JsValue.from_str (str.from "\"Hello from rust!\""))
                )

            ()


        member _.get_item (item: string) (arg1: MutPtr<HashMapAsAService>) : int option =
            let compiler = arg1.deref_unsafe ()
            // no error checking because not implemented right now in fable
            let mapvalue: Ref<int> = cast compiler.value.dictionary[cast (Ref.from item)]
            Some mapvalue.deref

        member _.num_of_items(arg1: MutPtr<HashMapAsAService>) : int =
            let compiler = arg1.deref_unsafe ()
            let map = MutRef.from compiler.value.dictionary
            (emit "map.len() as i32" : int)

        member _.add_item
            (item: string)
            (value: int)
            (p: MutPtr<HashMapAsAService>)
            : string =
            let compiler = p.deref_unsafe ()
            compiler.value.dictionary.Add(item, value)
            let response = $"added item successfully!"
            response


        member _.alloc_compiler() =
            let comp: HashMapAsAService = { dictionary = Dictionary() }
            let mutptr = MutPtr.from_boxed (comp)
            mutptr

        member _.free_compiler(compiler) = MutPtr.drop compiler
    }

