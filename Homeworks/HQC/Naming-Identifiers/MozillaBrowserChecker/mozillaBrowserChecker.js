function checkIfBrowserIsMozilla() {
    var clientWindow = window,
        browser = clientWindow.navigator.appCodeName,
        isMozilla = browser == "Mozilla";
    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}