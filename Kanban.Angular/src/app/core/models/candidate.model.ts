export interface IItem {
  id: number;
  name: string;
}

export interface ICandidate {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  status: IItem;
  jobs: IItem[];
}

export interface ICandidateForm {
  firstName: FormDataEntryValue | null;
  lastName: FormDataEntryValue | null;
  email: FormDataEntryValue | null;
  phoneNumber: FormDataEntryValue | null;
  status?: number;
  job?: number;
  statusId?: number;
  jobIds?: number[];
}