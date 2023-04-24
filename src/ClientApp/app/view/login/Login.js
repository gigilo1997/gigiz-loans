
Ext.define('ClientApp.view.login.Login',{
    extend: 'Ext.window.Window',
    xtype: 'login',

    requires: [
        'ClientApp.view.login.LoginController',
        'ClientApp.view.login.LoginModel'
    ],

    controller: 'login-login',
    viewModel: {
        type: 'login-login'
    },

    title: 'Login User',
    width: 300,
    height: 200,

    closable: false,
    autoShow: true,

    layout: 'fit',

    items: [{
        xtype: 'form',
        reference: 'loginform',
        layout: 'anchor',
        bodyPadding: 10,

        fieldDefaults: {
            allowBlank: false,
            anchor: '100%',
            msgTarget: 'side'
        },

        items: [{
            xtype: 'textfield',
            name: 'username',
            fieldLabel: 'User Name',
        }, {
            xtype: 'textfield',
            name: 'password',
            inputType: 'password',
            fieldLabel: 'Password',
        }]

    }],

    buttons: [{
        text: 'Login',
        listeners: {
            click: 'onButtonLoginClick'
        }
    }, {
        text: 'Register',
        listeners: {
            click: 'onButtonRegisterClick'
        }
    }]
});
