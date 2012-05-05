window.RenderControl = function (control, callback) {
    var path = window.basePath + "/ControlRender?control=" + control;
    $.get(path, callback);
}