import { FFmpeg } from "./libs/ffmpeg/main/dist/esm/index.js";
import { fetchFile, toBlobURL } from "./libs/ffmpeg/util/dist/esm/index.js";

var ffmpeg = new FFmpeg();

export async function init(objRef) {

    ffmpeg.on("log", ({ message }) => {
        objRef.invokeMethodAsync("LogMessage", message);
    });

    await ffmpeg.load({
        coreURL: "/js/libs/ffmpeg/core/dist/esm/ffmpeg-core.js",
        wasmURL: "/js/libs/ffmpeg/core/dist/esm/ffmpeg-core.wasm"
    });

    await ffmpeg.exec("-h");
}