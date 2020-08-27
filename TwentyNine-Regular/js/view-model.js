let appStart = () => {
    loadView(RoutingConst.Components.authGate);

    $.ajax({
        url: RoutingConst.CasinoBE + '/User/CheckRegistration?id=' + Player.contextId,
        type: 'GET',
        statusCode: {
            204: () => {                
                Swal.fire({
                    title: '<strong>Hello ' + Player.playerName + '!!</strong>',
                    icon: 'info',
                    html:
                    'You can use <b>bold text</b>, ' +
                    '<a href="//sweetalert2.github.io">links</a> ' +
                    'and other HTML tags',
                    showCloseButton: true,
                    showCancelButton: true,
                    focusConfirm: false,
                    confirmButtonText:
                    '<i class="fa fa-thumbs-up"></i> Great!',
                    confirmButtonAriaLabel: 'Thumbs up, great!',
                    cancelButtonText:
                    '<i class="fa fa-thumbs-down"></i>',
                    cancelButtonAriaLabel: 'Thumbs down'
                });
            }, 
            200: () => {
                alert('User Found');
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