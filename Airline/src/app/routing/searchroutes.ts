import { SearchComponent } from "../search/search.component";
import { SearchByEmailIdComponent } from "../search/searchbyemailid.component";
import { SearchByPNRComponent } from "../search/searchbypnr.component";


export const Searchroutes = [

    { path: 'Add', component: SearchComponent },
    { path: 'EmailId', component: SearchByEmailIdComponent },
    { path: 'PNR',component:SearchByPNRComponent}]
