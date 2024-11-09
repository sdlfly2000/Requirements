import { User } from './user';

export interface Project {
  id?: string | undefined;
  name?: string | undefined;
  key?: string | undefined;
  url?: string | undefined;
  description?: string | undefined;
  avatarUrl?: string | undefined;
  category?: ProjectCategory | undefined;
  leader?: User | undefined;
  createdAt?: string | undefined;
  updatedAt?: string | undefined;
  assignees: User[];
}

export type ProjectCategory = 'Software' | 'Marketing' | 'Business';
