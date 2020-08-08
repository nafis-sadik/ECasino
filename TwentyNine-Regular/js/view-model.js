let appStart = () => {
    loadView(RoutingConst.Components.authGate);
    $.ajax({
        url: RoutingConst.CasinoBE + '/User/CheckRegistration?id=' + Player.contextId,
        type: 'GET',
        success: (res) => {
            console.log(res);
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