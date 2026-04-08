export interface ProductCard {
  id: number,
  name: string,
  priceMonthly: number,
  priceYearly: number,
  priceYearlyDiscounted: number,
  descriptionItems: DescriptionItem[]
}

export interface DescriptionItem {
  mainText: string,
  subText: string
}
