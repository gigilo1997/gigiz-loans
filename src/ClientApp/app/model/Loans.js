Ext.define('ClientApp.model.Loans', {
    extend: 'ClientApp.model.Base',

    fields: [
        'id', 'type', 'amount', 'currency', 'loanYears', 'loanMonths', 'loanDays', 'status'
    ]
});
