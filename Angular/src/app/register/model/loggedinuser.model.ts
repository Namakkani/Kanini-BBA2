export class LoggedInUserModel{
    constructor(
        public id:string="",
        public token:string="",
        public role:string="",
        public log_status:boolean=false)
    {

    }
    
  }
