function getManger(id) {
    // $.ajax({
    //     url: "/instructor/getCard/"+id,
    //     success: function (result) {
    //         console.log(result);
    //         var area = document.getElementById("manger");
    //         area.innerHTML = result;
    //     }
    // });
    //  event.preventDefault();
    //  console.log(id)
    // var result = await fetch("/Instructor/GetCard/" + id);
    //  console.log(result);
    //  var data = await result.text();
    //  console.log(data);

    //  var area = document.getElementById("manger");
    //  area.innerHTML = data;



    $.ajax({
        url: "/instructor/getData/" + id,
        success: function (result) {
            console.log(result);
            var area = document.getElementById("manger");
            area.innerHTML = `<p>Name: ${result.name}<\p><br>
                    <p>Degree: ${result.degree}</p>`;
        }
    });
}