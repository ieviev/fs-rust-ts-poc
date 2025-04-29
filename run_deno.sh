#!/usr/bin/env bash

set -euo pipefail
wd=$(dirname "$0")

deno --allow-read=pkg/rust_library_bg.wasm --unstable-sloppy-imports --unstable-detect-cjs ./src/fs-rust-ts.ts/Typescript.fs.ts