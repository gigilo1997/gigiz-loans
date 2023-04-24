Ext.define('ClientApp.view.login.LoginController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.login-login',

    onButtonLoginClick: function(button) {
        var me = this;

        var form = this.lookup('loginform');

        form.submit({
            url: 'https://localhost:7000/api/Auth/GenerateToken',
            success: function(form, action) {
                console.log("Logging In");
                var data = JSON.parse(action.response.responseText);
                localStorage.setItem('token', data.message.token);

                me.getView().destroy();
                window.location.reload();
                Ext.create({
                    //xtype:'app-main'
                    xtype:'loanlist'
                });
            },
            failure: function(form, action) {

                if(action.response != null) {
                    var data = JSON.parse(action.response.responseText);
                    if(data != null) {
                        Ext.MessageBox.alert('Error', data.data.message);
                    } else {
                        Ext.MessageBox.alert('Error', action.response.statusText);
                    }
                }
            }
        })

    },

    onButtonRegisterClick: function(button) {
        var me = this;

        me.getView().destroy();
        Ext.create({
            xtype:'register'
        });
    }
});
