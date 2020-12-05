function showhide(id) {
    var div = document.getElementById("div_" + id);
    var button = document.getElementById("button_" + id);

    if (div.style.display === "block") {
        div.style.display = "none";
        button.innerHTML = "Show";
    } else {
        div.style.display = "block";
        button.innerHTML = "Hide"
    }
}