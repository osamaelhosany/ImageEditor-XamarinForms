/*
Load this script immediatley after jQuery, or as as early as possible.
Then use .beforeReady to execute code before any .ready() functions, e.g.
$.beforeReady(function() {
  alert("Ere I am JH")
});
Here is an example html file showing how the .beforeReady() function executes before the .ready() function.
<html>
    <head>
        <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
        <script src="jquery-before-ready.js"></script>
    </head>
    <body>
        <script>
            $(document).ready({
                alert("This function is declared first!")
            })
        </script>
        <script>
            $.beforeReady(function(){
                alert("This function is declared second but executes first!")
            })
        </script>        
    </body>
</html>
*/



jQuery.beforeReadyPrivateArray = []
jQuery.beforeReady = function (handler) {
    jQuery.beforeReadyPrivateArray.push(handler)
}

$(function () {
    var arrayLength = jQuery.beforeReadyPrivateArray.length;
    for (var i = 0; i < arrayLength; i++) {
        jQuery.beforeReadyPrivateArray[i]()
    }
})
