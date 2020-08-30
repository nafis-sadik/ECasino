let appStart = (player) => {
    loadView(RoutingConst.Components.authGate);
    if(player == null || player == NaN || player == undefined)
        return;
    $.ajax({
        url: RoutingConst.CasinoBE + '/User/CheckRegistration?id=' + player.PlayerID,
        type: 'GET',
        statusCode: {
            204: () => {                
                Swal.fire({
                    title: '<strong>Hello ' + player.UserName + '!!</strong>',
                    icon: 'info',
                    html:
                    'Looks like you are <b>new here!</b> <br> ' +
                    'Please sing up to proceed',
                    showCloseButton: true,
                    showCancelButton: true,
                    focusConfirm: true,
                    confirmButtonText:'Sing Up!',
                    cancelButtonText:'Cancel',
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    footer: '<a href>Terms and Conditions</a>'
                }).then((result) => {
                    if (result.value) {
                        $.ajax({
                            url: RoutingConst.CasinoBE + '/User/RegisterNewUser',
                            type: 'POST',
                            data: player,
                            success: () => {          
                                Swal.fire(
                                    'Registered!',
                                    'Your blume account has been registered.',
                                    'success'
                                );
                            },
                            error: () => {
                                Swal.fire(                                    
                                    'Failed!',
                                    'FGailed to sign you up!',
                                    'error'
                                );
                            }
                        });
                    }
                });
            }, 
            200: () => {
                Swal.fire({
                    icon: 'success',
                    title: 'Wellcome Back ' + player.UserName + '!!',
                    showConfirmButton: false
                });
            }
        },
        error: (res) => {
            console.log(res);
        }
    });
}

let loadView = (viewUri) => {
    $.ajax({
        url: viewUri + 'Component.html',
        success: (res) => {
            $('#view-port').empty();
            $('#view-port').append(res);
        },
        error: (res) => {
            console.error(res);
        }
    });
}