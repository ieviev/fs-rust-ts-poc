# F\# to Rust & Typescript app proof of concept

this is a proof of concept to 
write Typescript and Rust (wasm32) apps with type-safe communication over wasm boundary
by generating the whole app from F\#

```
shared definitions: src/fs-rust-ts.shared/Shared.fs
wasm source: src/fs-rust-ts.rs/Rust.fs
typescript (deno) app: src/fs-rust-ts.ts/Typescript.fs
```

`run_deno.sh` starts the application

`watcher.fsx` contains the dev scripts


The rust side currently only works with this (experimental) fork of Fable: https://github.com/ieviev/Fable/tree/fsil

This fork is: 
1. To rather write F\#-flavored Rust than convert working F\# to Rust (so no F\# standard library at all)
2. To prioritize extending the application to rust libraries and making existing rust code usable

There's a lot of work to do with bindings for it to be actually usable

Another problem is that you cannot pass different DefineConstant values into a shared project

