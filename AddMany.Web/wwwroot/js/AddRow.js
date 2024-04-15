$(() => {
    let num = 1;
    $("#add-row").on('click', function () {
        
        $("#ppl-rows").append(` <div>
                <div class="row" style="margin-bottom: 10px;">
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="p[${num}].Firstname" placeholder="First Name" />
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="p[${num}].LastName" placeholder="Last Name" />
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text" name="p[${num}].Age" placeholder="Age" />
                    </div>

                </div>

            </div>`);

        num++;

        console.log("hello");
    });

})
