import {Category} from "./category";

export class Product {
  id?: number;
  name?: string;
  categoryId?: number;
  price?: number;
  photoUrl?: string
  category?: Category
}
