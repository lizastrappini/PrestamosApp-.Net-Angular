import { Loan } from "./loan";

export interface Thing {
    Id?:number | undefined;
    Description: string | null | undefined;
    CreationDate: Date | null | undefined,
    IdCategory: number,
    PersonDni: number,
    Loan? : Loan | null
}
