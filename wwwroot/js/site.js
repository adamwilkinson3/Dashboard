// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {
    
    $(`#${sessionStorage.getItem('sidebar')}`).addClass("show");

    $(".tab1").click(function() {
        sessionStorage.setItem('sidebar', 'collapseOne');
    });
    $(".tab2").click(function () {
        sessionStorage.setItem('sidebar', 'collapseTwo');
    });
    $(".tab3").click(function () {
        sessionStorage.setItem('sidebar', 'collapseThree');
    });

});