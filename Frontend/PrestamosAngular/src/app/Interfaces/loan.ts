export interface Loan {
    Id?: number; 
    ReturnDate: Date | null | undefined;
    CreationDateTime: Date;
    Status: string;
    DniPerson: number | null;
    IdThing: number | undefined;
    BorrowerName: string | null | undefined;
}
