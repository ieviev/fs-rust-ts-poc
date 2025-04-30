# F\# to Rust & Typescript app proof of concept

this is a proof of concept to 
write Typescript and Rust (wasm32) apps with type-safe communication over wasm boundary
by generating the whole app from F\#


- shared wasm bindings: `src/fs-rust-ts.ts/wasm_bindgen.fs`
- shared api definition: `src/fs-rust-ts.ts/Shared.fs`
- wasm source: `src/fs-rust-ts.rs/Rust.fs`
- typescript (deno) app: `src/fs-rust-ts.ts/Typescript.fs`


The rust side currently only works with this (experimental) fork of Fable: https://github.com/ieviev/Fable/tree/fsil

This fork is: 
1. To write F\#-flavored Rust instead of converting F\# to Rust (no F\# standard library at all)
2. To prioritize extending the application to rust libraries and making existing rust code usable over wasm

There's a lot of work to do with bindings for it to be actually usable

Another problem is that you cannot pass different DefineConstant values into a shared project, so the file has to be imported directly

