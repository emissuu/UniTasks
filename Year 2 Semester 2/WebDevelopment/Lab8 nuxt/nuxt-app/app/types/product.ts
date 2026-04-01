export interface Product {
  id: number;
  name: string;
  priceMonthly: number;
  priceYearly: number;
  priceYearlyDiscounted: number;
  isFreeTrialAvailable: boolean;
  descriptionItems: DescriptionItem[];
}

export interface DescriptionItem {
  mainText: string;
  subText: string;
}
