export interface SelectionProcessRequest {
    id: string;
    name: string;
    startDate: Date;
    endDate: Date;
    recruiters: string[];
    processState: number;
}