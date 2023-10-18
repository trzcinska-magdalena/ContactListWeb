export interface Contact {
  id: number
  name: string
  surname: string
  email: string
  password: string
  phone: string
  birthDate: any
  categoryID: number
  subcategoryID: number | null
  subcategoryOther: string | null
}
