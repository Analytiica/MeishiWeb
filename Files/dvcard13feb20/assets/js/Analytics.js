import { AnalyticalService } from "./service/AnalyticalService";

export function initEvent() {

    console.log("hi there");
    const anaylitcsService = new AnalyticalService();
    anaylitcsService.saveStatistics();

    // anaylitcsService.initEvent();

}
