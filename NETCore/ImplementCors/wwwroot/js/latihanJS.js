$(document).ready(function () {
    $.ajax({
        url: "https://pokeapi.co/api/v2/pokemon"
    }).done((result) => {
        console.log(result);
        //mengambil data
        console.log(result.results[3]);

        var text = "";
        //menampil kan data
        $.each(result.results, function (key, val) {
            text += `<tr">
            <td>${key + 1}</td>
            <td>${val.name}</td>
            <td><button type="button"
                        class="btn btn-primary"
                        data-toggle="modal"
                        onclick="detail('${ val.url }')">Detail</button></td>
                </tr>`;
        });
        $("#swapi").html(text);

    }).fail((result) => {
        console.log(result);
    });
});
function detail(url) {
    $.ajax({
        url: url
    }).done((result) => {
        console.log(result);
        //menampil kan data
        var img = "";
        var text = "";
        var type = "";
        var ability = "";
        img = `<div class="row" id="pict">
                    <img src=${result.sprites.other.dream_world.front_default} class="rounded mx-auto d-block" alt="Responsive image">
                </div>`
        //$.each(result.moves.move, function (key, val) {
        //    move += `<li class="list-group">: ${key+1} ${val.name}</li>`;
        //});
        for (let i = 0; i < result.abilities.length; i++) {
            ability += `<div class="row col-8">
                            <li class="list-group">: ${i+1}.  ${result.abilities[i].ability.name}</li>
                        </div>`;
        }
        console.log(ability);
        text = ` <div class="row ">
                    <div class="col-4 ">
                        <ul>
                            <li class="list-group">Nama</li>
                            <li class="list-group">Heigt</li>
                            <li class="list-group">Weight</li>
                            <li class="list-group">Ability</li>
                        </ul>
                    </div>
                    <div class="col-8" id="data">
                        <ul>
                    <li class="list-group">: ${result.name}</li>
                    <li class="list-group">: ${result.height}</li>
                    <li class="list-group">: ${result.weight}</li>
                     `
        //move = ``;
        for (let i = 0; i < result.types.length; i++) {
            if (result.types[i].type.name == 'grass') {
                type += `
                    <span class="badge badge-success">Grass</span>`;

            } if (result.types[i].type.name == 'poison') {
                type += `
                    <span class="badge badge-dark">Poison</span>`;
            } if (result.types[i].type.name == 'fire') {
                type += `
                    <span class="badge badge-danger">Fire</span>`;
            } if (result.types[i].type.name == 'flying') {
                type += `
                    <span class="badge badge-warning">Flying</span>`;
            } if (result.types[i].type.name == 'water') {
                type += `
                    <span class="badge badge-primary">Water</span>`;
            } if (result.types[i].type.name == 'bug') {
                type += `
                    <span class="badge badge-secondary">Bug</span>`;
            } if (result.types[i].type.name == 'normal') {
                type += `
                    <span class="badge badge-light">Normal</span>`;
            }
        }
        $("#dataModal").modal('show');
        $(".modal-body").html(img+type+text+ability);
    }).fail((result) => {
        console.log(result);
    });
};
//$(document).ready(function () {
//    function detail(url)
//});
//$(document).ready(function () {
//    $(`.click${key+1}`).click(function () {
//        $.ajax({
//            url: "https://swapi.dev/api/people"
//        }).done((result) => {
//            var key = document.getElementById(`result${key + 1}`);
//            var text = "";
//            //menampil kan data
//            console.log(key);
//            $.each(result.results[key], function (key, val) {
//                text += `<tr>
//                <td>${val.name}</td>
//                </tr>`;
//            });
//            $("#detail_user").html(text);
//            $("#dataModal").modal('show');
//        }).fail((result) => {
//            console.log(result);
//        }); 
//    });
//});