open System.Diagnostics
open System.IO
open System
open System.Threading

// all paths are relative to this file
Directory.SetCurrentDirectory __SOURCE_DIRECTORY__
let time_between_s = 0.2

let thread fn =
    let t = Thread(ThreadStart(fn))
    t.Start()
    t

let start_process(pname: string, pargs: string, cwd: string) =
    thread (fun _ ->
        let info =
            ProcessStartInfo(fileName = pname, arguments = pargs, WorkingDirectory = cwd)

        use p = new Process(StartInfo = info)

        if not (p.Start()) then
            failwith "could not start process"

        p.WaitForExit())

let watch_file (file: string) onChanged =
    thread (fun _ ->
        use watcher =
            new FileSystemWatcher(
                Path.GetDirectoryName(file),
                Path.GetFileName(file),
                EnableRaisingEvents = true,
                IncludeSubdirectories = false
            )

        let mutable nextproctime = DateTimeOffset.Now

        while true do
            let changed = watcher.WaitForChanged(WatcherChangeTypes.Changed)

            match DateTimeOffset.Now > nextproctime with
            | false -> ()
            | true ->
                onChanged changed
                nextproctime <- (nextproctime.AddSeconds(time_between_s)))

// ---------

let start_compiling_rust() =
    start_process (
        "/usr/bin/env",
        String.concat " " [ "fable watch --optimize --lang rs" ],
        "src/fs-rust-ts.rs"
    )
    |> ignore

let start_compiling_typescript() =
    start_process ("/usr/bin/env", String.concat " " [ "fable watch --lang ts" ], "src/fs-rust-ts.ts")
    |> ignore


let run_wasm_pack_on_change() =
    watch_file "src/fs-rust-ts.rs/Rust.fs.rs" (fun v ->
        let t =
            start_process (
                "/usr/bin/env",
                String.concat " " [
                    "wasm-pack build -t nodejs --dev --no-opt --out-dir pkg/"
                ],
                ""
            )

        t.Join() |> ignore)

let run_deno_on_change() =
    watch_file "src/fs-rust-ts.ts/Typescript.fs.ts" (fun v ->
        let t =
            start_process (
                "/usr/bin/env",
                String.concat " " [
                    "deno"
                    "--allow-read=pkg/rust_library_bg.wasm"
                    "--unstable-sloppy-imports"
                    "--unstable-detect-cjs"
                    "./src/fs-rust-ts.ts/Typescript.fs.ts"
                ],
                ""
            )

        t.Join() |> ignore)

start_compiling_rust ()
start_compiling_typescript ()
run_deno_on_change ()
run_wasm_pack_on_change ()

let resetevent = new System.Threading.ManualResetEvent(false)
resetevent.WaitOne()
